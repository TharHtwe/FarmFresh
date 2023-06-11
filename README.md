# FarmFresh
A sample project for online supermarket offering a huge range of grocery products using ASP.NET Core with EF 6 && Angular.

# FarmFresh-API
API backend to handle authentication, products, categories, etc with Policy-based authorization for both admin and client.

## API Endpoints
### Admin
> #### GET: /api/admin/authenticate : return { Token = {JWT_Token} }
> To get JWT token using email and password
> #### GET: /api/categories
> List all categories
> #### POST: /api/categories
> Insert new category
> #### GET: /api/products?page=1&pageSize=10&orderBy=&direction=&search=
> List all products including category with pagination and filter
> #### GET: /api/products/{id}
> Get product with category and stock infos by id
> #### POST: /api/products
> Create new product
> #### PUT: /api/products/{id}
> Update product info by id
> #### DELETE: /api/products/{id}
> Delete product by id
> #### GET: /api/units
> List all units
> #### POST: /api/units
> Insert new unit
> #### POST: /api/upload
> Upload images and return corresponding paths
### User
> #### GET: /api/authenticate : return { Token = {JWT_Token} }
> To get JWT token using email and password
> #### GET: /api/categories
> List all categories
> #### GET: /api/products?page=1&pageSize=10&orderBy=&direction=&search=
> List all products including category with pagination and filter
## To Test
You may need to change FarmFreshConnectionString from appsettings.json.

Run following command at Package Manager Console
```
Update-Database
```
# FarmFresh-API
Admin interface to handle CRUD operations of product, category, etc
## To Test
Change api url according to FarmFresh-API's host
#### **`src\environments\environment.development.js`**
``` js
baseApiUrl: 'https://localhost:{your_port}'
```
# FarmFresh-Client
To show FarmFresh products, promotions, etc to visiting user.
## To Test
Change api url according to FarmFresh-API's host
#### **`src\environments\environment.development.js`**
``` js
baseApiUrl: 'https://localhost:{your_port}'
```
