using Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ItemRepository : IItem
    {
        private readonly ApplicationDbContext _dbcontext;
        public ItemRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region Queries
        public bool Exist(int id)
        {
            var res = _dbcontext.Item.Count(x => x.Id == id);
            return res > 0;
        }

        public async Task<Item> GetSingle(int id)
        {
            var model = await _dbcontext.Item
                .Where(x => x.Id == id && x.Eliminado == false)
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<Item>> GetAll()
        {
            var listItems = await _dbcontext.Item
                            .Where(l => l.Eliminado == false)
                            .ToListAsync();

            return listItems;
        }

        public Task<List<Item>> GetAllPaginated(int page, int sizePage)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> Search(string text)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region commands

        public async Task<int> Create(Item element)
        {
            var paramId = new SqlParameter("@id", SqlDbType.Int);
            paramId.Direction = ParameterDirection.Output;

            await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC uspItemCrear @idLista={element.IdLista}, 
                                     @descripcion={element.Descripcion}, 
                                     @completado={element.Completado},
                                     @id={paramId} OUTPUT"
            );

            if (paramId != null)
            {
                return (int)paramId.Value;
            }

            return 0;
        }

        public async Task<int> Update(Item element)
        {
            await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                            $@"EXEC uspItemUpdate   @id={element.Id},
                                                    @idLista={element.IdLista},
                                                    @descripcion={element.Descripcion}, 
                                                    @completado={element.Completado}"
            );

            return element.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                           $@"EXEC uspItemEliminar @id={id}");

            return res > 0;
        }

        public async Task<bool> DeleteLogic(int id)
        {
            var res = await _dbcontext.Database.ExecuteSqlInterpolatedAsync(
                            $@"EXEC uspItemEliminacionLogica @id={id}"
            );

            return res > 0;
        }

        
        #endregion
    }
}
