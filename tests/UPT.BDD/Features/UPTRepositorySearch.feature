# language: es
Característica: Búsqueda en Repositorio UPT
  Como estudiante de la UPT
  Quiero encontrar tesis de tecnología en el Repositorio de la UPT
  Para investigar sobre tecnologías recientes y tener referencias

  Escenario: Acceder al repositorio UPT exitosamente
    Dado que soy un estudiante de la UPT
    Cuando accedo al sitio web del repositorio
    Entonces debo ver la página principal del repositorio

  Esquema del escenario: Buscar tesis sobre diferentes tecnologías
    Dado que como estudiante tengo acceso al repositorio
    Cuando realizo una búsqueda de "<tecnologia>"
    Entonces espero tener uno o muchos resultados

    Ejemplos:
      | tecnologia               |
      | web                      |
      | base de datos            |
      | movil                    |
      | business intelligence    |
      | inteligencia artificial  |

  Escenario: Buscar tesis sobre tecnología web
    Dado que como estudiante quiero investigar sobre desarrollo web
    Cuando busco tesis relacionadas con "web"
    Entonces los resultados deben contener información sobre web

  Escenario: Buscar tesis sobre bases de datos
    Dado que como estudiante quiero investigar sobre bases de datos
    Cuando busco tesis relacionadas con "base de datos"
    Entonces los resultados deben contener información sobre bases de datos

  Escenario: Buscar tesis sobre desarrollo móvil
    Dado que como estudiante quiero investigar sobre aplicaciones móviles
    Cuando busco tesis relacionadas con "movil"
    Entonces los resultados deben contener información sobre desarrollo móvil

  Escenario: Buscar tesis sobre inteligencia artificial
    Dado que como estudiante quiero investigar sobre IA
    Cuando busco tesis relacionadas con "inteligencia artificial"
    Entonces los resultados deben contener información sobre inteligencia artificial

  Escenario: Buscar tesis sobre business intelligence
    Dado que como estudiante quiero investigar sobre BI
    Cuando busco tesis relacionadas con "business intelligence"
    Entonces los resultados deben contener información sobre business intelligence
