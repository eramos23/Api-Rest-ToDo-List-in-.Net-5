using Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ListaRepository : ILista
    {
        private readonly ApplicationDbContext _dbcontext;
        public ListaRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region Queries
        public bool Exist(int id)
        {
            var res = _dbcontext.Lista.Count(x => x.Id == id && x.Eliminado == false);
            return res > 0;
        }

        public int Total()
        {
            var res = _dbcontext.Lista.Count(x => x.Eliminado == false);
            return res;
        }

        public async Task<Lista> GetSingle(int id)
        {
            var model = await _dbcontext.Lista
                .Where(x => x.Id == id && x.Eliminado == false)
                .Include(l => l.Items).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<Lista>> GetAll()
        {
            var listModels = await _dbcontext.Lista
                            .Where(l => l.Eliminado == false)
                            .ToListAsync();

            return listModels;
        }

        public async Task<List<Lista>> GetAllPaginated(int page, int sizePage)
        {
            var books = await _dbcontext.Lista
                            .FromSqlInterpolated(
                                $@"EXEC uspListaPaginada @pagina={page},
                                @tamanioPagina={sizePage}"
                            ).ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Lista>> Search(string text)
        {

            var listModels = await (from lista in _dbcontext.Lista
                             where lista.Titulo.Contains(text) || lista.Descripcion.Contains(text)
                             select lista).ToListAsync();
            return listModels;
        }
        #endregion

        #region commands
        public async Task<int> Create(Lista element)
        {
            using (var dbTran = _dbcontext.Database.BeginTransaction())
            {
                var idLista = new SqlParameter("@id", SqlDbType.Int);
                try
                {
                    idLista.Direction = ParameterDirection.Output;

                    _dbcontext.Database
                        .ExecuteSqlInterpolated($@"EXEC uspListaCrear 
                            @titulo={element.Titulo}, 
                            @descripcion={element.Descripcion},
                            @id={idLista} OUTPUT"
                    );

                    foreach (var item in element.Items)
                    {
                        var idItem = new SqlParameter("@id", SqlDbType.Int);
                        idItem.Direction = ParameterDirection.Output;
                        item.IdLista = (int)idLista.Value;

                        await _dbcontext.Database
                               .ExecuteSqlInterpolatedAsync($@"EXEC uspItemCrear 
                                    @idLista={item.IdLista}, 
                                    @descripcion={item.Descripcion}, 
                                    @completado={item.Completado},
                                    @id={idItem} OUTPUT"
                           );
                    }
                    await dbTran.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbTran.RollbackAsync();
                    throw;
                }

                if (idLista != null)
                {
                    return (int)idLista.Value;
                }

                return 0;
            }
        }

        public async Task<int> Update(Lista element)
        {
            using (var dbTran = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    await _dbcontext.Database
                                    .ExecuteSqlInterpolatedAsync($@"EXEC uspListaUpdate
                                    @id={element.Id},
                                    @titulo={element.Titulo}, 
                                    @descripcion={element.Descripcion}");

                    foreach (var item in element.Items)
                    {
                        if (item.Id > 0) //UPDATE
                        {
                            await _dbcontext.Database
                            .ExecuteSqlInterpolatedAsync($@"EXEC uspItemUpdate
                            @id={item.Id},
                            @idLista={item.IdLista},
                            @descripcion={item.Descripcion}, 
                            @completado={item.Completado}");
                        }
                        else
                        { // INSERT
                            var idItem = new SqlParameter("@id", SqlDbType.Int);
                            idItem.Direction = ParameterDirection.Output;

                            await _dbcontext.Database
                                   .ExecuteSqlInterpolatedAsync($@"EXEC uspItemCrear 
                                    @idLista={item.IdLista}, 
                                    @descripcion={item.Descripcion}, 
                                    @completado={item.Completado},
                                    @id={idItem} OUTPUT"
                               );
                        }

                    }
                    await dbTran.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbTran.RollbackAsync();
                    throw;
                }

                return element.Id;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                           $@"EXEC uspListaEliminar @id={id}");

            return res > 0;
        }

        public async Task<bool> DeleteLogic(int id)
        {
            var res = await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                            $@"EXEC uspListaEliminacionLogica @id={id}"
            );

            return res > 0;
        }

        #endregion

        
    }
}
