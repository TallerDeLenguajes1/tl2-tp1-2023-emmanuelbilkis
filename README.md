# tl2-tp1-2023-emmanuelbilkis
¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?

En este contexto y como se dio la solucion considero las siguientes relaciones entre clase.
Cliente - Pedido --> Asociación de Composición.
Pedido -Cadete --> Asociación de Agregación.
Cadete -Cadeteria --> Asociación de Agregación.

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

Métodos cadetería 
Un pedido desde su nacimiento está ligado a un cadete, esto desde cadetería. Esto es por este contexto ya que está implementación que no es la mejor. Sería generar agregar pedido ( este llamará al agregar pedido del cadete en particular, hace uso del agregar pedido de la clase cadete). Esto por separación de responsabilidad. 
Método de cadete disponible también a futuro. Porq no hay una limitación de cuántos pedidos pueden tener en total. Ahora podría ser el método  si existe el cadete.
Reasignar pedido a otro cadete.
Eliminar pedido
Generar informe. 
Casi todo los métodos de cadetería había similares en cadetes por la conexión q hay. Hay como una relación uno a uno entre los métodos. 


Las responsabilidades de quién manipula realmente la lista de pedidos es de Cadete. Cadetería no puede hacer lo q quiera con esa lista. Puede tener métodos para acceder, pero quién la manipula es Cadete. Acordate del término de mensajes.

Cambiar de estado puede ser q haya dos estados y dentro de la lógica del método podrías hacer q pase de uno al otro. No pasaría el nuevo estado por parámetro aquí. 

Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados ?

Los métodos serían publicos y los atributos privados. En general lo que no quiero que acceda y manipule otras clases o el usuario seria private.

¿Cómo diseñaría los constructores de cada una de las clases?

NombreClase(tipo par1,tipo par2,...,tipo parn)
{
  logica que se implementara de acuerdo a lo   requerido. Seguramente habra uno de la siguiente manerra:
   atributo1= par1
   atributo2 = par2
   ...
   atributon=parn
} 

¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?




