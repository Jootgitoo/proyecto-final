### TABLA USUARIO
- idUsuario --> int, not null, auto incremental
- nombreUsuario --> varchar(50), not null
- primerApellido --> varchar(100), not null
- email --> varchar(150), unique
- password --> varchar(100), not null
- fecha_nacimiento --> Date, not null
- sexo --> varchar(10), not null 
- peso --> double, not null
- altura --> double, not null
- tipo_dieta --> varchar(100), not null

### TABLA ALERGIA
- idAlergia --> int, not null, auto incremental, PK
- nombreAlergia --> varchar(50), not null

### TABLA PRODUCTO
- idProducto --> int, not null, auto incremental
- nombreProducto --> varchar(50), not null
- urlImagen --> varchar(255), not null
- contieneGluten --> boolean, not null // true --> si contiene, false --> no contiene
- precioProducto --> double, not null
- idTipoProducto --> FK

### TABLA TIPOPRODUCTO
- idTipoProducto, int, auto incremental, PK
- nombreTipoProducto, varchar(50), not null 

### TABLA RECETA
- idReceta --> int, not null, auto incremental
- nombreReceta --> varchar(150), not null
- tiempoPreparacion --> int,  not null
- urlImagen --> varchar(75), not null
- descripcion --> varchar(256), not null
- vegetariano --> boolean, not null // true --> si pueden comerlo, false --> no pueden
- vegano --> boolean, not null // true --> si pueden comerlo, false --> no pueden
- sinGluten --> boolean, not null // true --> no tiene gluten, false --> si tiene gluten
- instrucciones --> varchar(256), not null
- calorias --> double, not null

### TABLA RECETAS_PRODUCTO
- idReceta --> FK, PK
- idProducto --> FK, PK
- cantidad  --> int, not null

### TABLA USUARIO_ALERGIA
- idUsuario --> FK, PK
- idAlergia --> FK, PK

### TABLA RECETAS_FAVORITA
- idUsuario, FK, PK, 
- idReceta, FK, PK
- fechaGuardado DATETIME --> Fecha justo de guardado
