[![Build Status](https://dev.azure.com/johnshrader/irish-railways-api/_apis/build/status/jpshrader.irish-railways-api?branchName=master)](https://dev.azure.com/johnshrader/irish-railways-api/_build/latest?definitionId=1&branchName=master)

# Irish Railways REST Api
This REST api is based off of the [Irish Rail Realtime API](http://api.irishrail.ie/realtime).

Future Enhancements:
 * Implement caching layer so this doesn't cause any unnecessary burden on their servers.
 * Add query string support to existing endpoints.

## Local Development


### Running the Api

In order to hit the local api, navigate to: `http://localhost:5000/`
 * Ex. `http://localhost:5000/api/stations/`


### Viewing Swagger Docs

In order to hit swagger on the local api, navigate to: `http://localhost:5000/swagger/ui/index.html#/`
 * The Json payload can be found by navigating to: `http://localhost:5000/swagger/v1/swagger.json`

