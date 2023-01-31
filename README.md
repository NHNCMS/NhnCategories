# NHN Categories Microservice

## Introduction
The NHN Categories Microservice is a component of the NHN project that exposes a group of endpoints to manage categories. This microservice provides the ability to create, update, edit, and delete Categories within the NHN system.

## Features
- Create new Categories
- Update existing Categories
- Edit category details
- Delete Categories

## Endpoints
The following endpoints are available for managing Categories:
- POST / - create a new category
- PUT /{id} - update an existing category
- GET /{id} - retrieve details for a single category
- DELETE /{id} - delete a category
- GET / - retrieve a list of all Categories

## Requirements
- NHN project
- .NET 7 or later
- Docker
- Kubernetes

## Installation
To install and run the microservice, follow these steps:
1. Clone the repository:
    git clone https://github.com/nhn/Categories-microservice.git
2. Start the Docker container:
    docker run -p 5000:5000 -d nhn/Categories-microservice:latest

## Contributing
Contributions to the microservice are welcome. 💕

## License
This microservice is released under the MIT license.

## Troubleshooting
If you encounter any issues with the deployment or usage of the microservice, consult the troubleshooting guide for possible solutions.

## Credits
This microservice has been created by the NHN team as part of the NHN project.
