# BookshopAPI

A generic API for your localhost to test and improve your API skills. You can use it to create or develop front end skills to pull data from the api.

## Database Credentials

This API uses SQL Server database

Database Name: BookShopAPI
User ID: APIUser
password: blackpool


## API URLs

http://api.bookshop.lab101.com/api/bookshop/genres - Use GET Method

http://api.bookshop.lab101.com/api/bookshop/authors - Use GET Method

http://api.bookshop.lab101.com/api/bookshop/books - Use GET Method

http://api.bookshop.lab101.com/api/bookshop/books/book/delete - Use Post method. Send a numebr value only. See Postman script for examples

http://api.bookshop.lab101.com/api/bookshop/books/save - Use Post method. Send book details in JSON format. See Postman script for examples

## API Set up

My API was hosted on my local machine.

In your IIS management, add a new website with an URL http://api.bookshop.lab101.com. It can be something else. Nothing of the features in the API are hard coded to use that URL.

Edit your hosts file to point 127.0.0.1 to point at http://api.bookshop.lab101.com (or your alterntaive URL).

In the web.config, change the database connection string, BookshopAPIDB, to your database set up. This can mean changing the data source, username or password.


