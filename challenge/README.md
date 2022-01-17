## Introduction

This project is part of a code challenge.

## Prerequisites

- .Net core 6 sdk

### How to run the project

_To compile the project:_

1. Install dependencies
   ```sh
   dotnet restore
   ```
2. build release
   ```sh
   dotnet publish -c Release
   ```

_To run inside docker:_

1. Run the two previous steps

2. Create the local docker image
   ```sh
   docker build -t challenge-image -f Dockerfile .
   ```
3. Run the docker image. If your 8080 port is already in use change it for another one.
   ```sh
   docker run -it --rm  -p 8080:80  --name challenge challenge-image
   ```
4. Check that you can access to http://localhost:8080/swagger/index.html

## TODO

- API versioning
- More tests!!!
- For translations that do not have a model (de -> fr). We need to do two steps for the translation de -> en -> fr.
- Read the API key from environment variables. Right now is hardcoded, easy for a bot to steal it.
- Proper error handling. For example detect the 3 translations per minute limit and return a controlled error.
- Improve swagger documentation. For example: Avoid numbers in ENUMS and use the string description for each value.
