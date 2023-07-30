# SETSRV
This is an asp.net 6.0 web api thats primary function is to get and store user settings and peripheral data.

# Running the program
## To run the API:

# Deploy
## To deploy the API:
### 1. Navigate to root Directory / program.cs directory with dockerfile
### 1. docker build -f ./Dockerfile -t setsrv_dev2 ../
### 2. docker login -u DOCKER_USER -p DOCKER_PASS dotnetcoreapi.azurecr.io
### 3. docker push dotnetcoreapi.azurecr.io/dotnet-api:latest
### 4. Connect docker with docker web app page