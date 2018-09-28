## Servicio API para ABM de usuarios
### Funcionamiento
El servicio API funciona bajo REST por lo que al hacer peticiones mediante la URL puede generar una serie de comandos
- http://localhost:8080/api/users mediante metodo GET genera una petición de toda la base datos
- http://localhost:8080/api/users/{id} mediante metodo GET genera una peticion de informacion de un usuario especifico mediante su id
- http://localhost:8080/api/{id} mediante metodo DELETE genera una peticion de eliminacion de un usuario especifico
- http://localhost:8080/api/user mediante metodo POST con data genera una peticion de creacion de usuario, data debe estar compuesto {Id:{id},name:{name},lastname:{lastname},email:{email},password:{password}}
- http://localhost:8080/api/user/{id} mediante metodo PUT con data genera una peticion de actualizacion de usuario, data debe estar compuesto {Id:{id},name:{name},lastname:{lastname},email:{email},password:{password}}
