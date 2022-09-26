import { ProductoUsuario } from "src/app/model/producto-usuario.model";
import { Producto } from "src/app/model/producto.model";

export const RepositoryProducto :Producto[] =
[
  {id:1, nombre:'Computador Intel Core I5',descripcion:'Computador con 1 tera de disco duro 32 gigas de memoria',cantidad:5,precio:1500000,imagen:'PC1.png'},
  {id:2,nombre:'Computador Intel Core I7',descripcion:'Computador con 1.5 tera de disco duro 40 gigas de memoria tarjeta gráfica de 2 gigas',cantidad:7,precio:2450000,imagen:'PC2.png'}
];


export const RepositoryProductoUsuario :ProductoUsuario[] =
[
  {id:1,idUsuario:1,idProducto:1, nombre:'Computador Intel Core I5',descripcion:'Computador con 1 tera de disco duro 32 gigas de memoria',cantidad:1,precio:1500000,imagen:'PC1.png'},
  {id:2,idUsuario:1,idProducto:2, nombre:'Computador Intel Core I7',descripcion:'Computador con 1.5 tera de disco duro 40 gigas de memoria tarjeta gráfica de 2 gigas',cantidad:2,precio:2450000,imagen:'PC2.png'}
];


