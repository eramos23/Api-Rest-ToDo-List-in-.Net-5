<strong><h3>Para ver la fuente, cambiar de rama a master</h3></strong>

# Api-Rest-ToDo-List-in-.Net-5
Este es una Api Rest- de un proyecto para realistas lista de tareas <strong>(To-Do List)</strong>
desarrollado en .Net 5 con la <strong>Arquitectura Onion</strong>(Una propuesta para mejorar la arquitectura N Capas)

[![dhti2v0e1smn055tages.png](https://i.postimg.cc/d0mDM8Lw/dhti2v0e1smn055tages.png)](https://postimg.cc/KKjmB3PH)


<strong><h3>En este proyecto se aplican los siguientes principios</h3></strong>

1)  <b>Principio de inversión de control</b>
Principio que permite que el trabajo y flujo de la aplicación se ha gestionado por un agente externo(otro framework o librería)

2)  <b>Principio de Inyección de dependencias</b>
Este principio permite inyectar componentes a las clases implentadas (los componentes son como contratos que necesitan nuestras clases para poder funcionar)


  <strong><h3>En este proyecto se aplican algunos patrones de diseño</h3></strong>
  
1)  <b>CQRS</b> 
Patron de desagregación de consultas y comandos
Separa la forma de leer y escribir datos

[![CQRS.png](https://i.postimg.cc/44FyT4N7/CQRS.png)](https://postimg.cc/0rDPYsSP)
  
  
  
2)  <b>Mediator</b>
Permite reducir la dependencia cahotica entre componentes, hace que los componentes no se comuniquen directamente entre ellos 
  
  [![Mediator-Pattern.png](https://i.postimg.cc/63WqByvR/Mediator-Pattern.png)](https://postimg.cc/Y4PM328q)

  
3)  <b>Patron de Repositorio</b>
El propósito del repositorio es ocultar los detalles del acceso a los datos. Podemos consultar fácilmente el repositorio de objetos de datos, sin tener que saber cómo proporcionar
- Diseño de responsabilidad única
- Repositorio generico
