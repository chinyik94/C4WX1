# C4WX1.API

This is a Web API project that provides several endpoints to communicate directly to the database through EF Core. 

Please note that we don't use any Repository/DataAccessLayer in this project as EF Core DbContext is already representing the layer.

## Project Structure

This project is attempting to use vertical slice to separate different tables as "Features". Each "Feature" will contain following folders:
- Create
- Get
- Update
- Delete
- Dtos
- Mappers
- Repository

More folder can be created to separate different type of classes as required.

### Create

This folder simply contain API for Create method through HTTP POST

### Get

This folder contains APIs for Get methods (whether it is GetOne or GetList) through HTTP GET

### Update

This folder contains API for Update method through HTTP PUT

### Delete

This folder contains API for Delete method through HTTP Delete

### Dtos

This folder contains all DTO definitions, whether it is for requests or responses

### Mappers

This folder contains all DTO to Entity or Entity to DTO mappers

### Repository

This folder contains shared EF Core logics that are more complex