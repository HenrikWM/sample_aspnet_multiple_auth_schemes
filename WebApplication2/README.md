# ASP.NET MVC API with multiple JWT bearer token authentication schemes

Generate a token at http://jwtbuilder.jamiekurtz.com/ using:

* secret key `qwertyuiopasdfghjklzxcvbnm123456`
* audience `https://localhost:7143/`

## Run and test JWT validation on two separate routes

1. Build and run the API
2. Use a REST client and make a GET to https://localhost:7143/weatherforecast using a JWT as Bearer token. This call should fail with 401 Unahtorized.
3. Use a REST client and make a GET to https://localhost:7143/tokenvalidation using a JWT as Bearer token. This call should succeed with 200 OK.