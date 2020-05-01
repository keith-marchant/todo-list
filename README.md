## Readme

This awesome todo app is a demo for API first design.

Our Open API specifications are written in YAML and split across multiple files by subject area. The root file is `todo-api.v1.yaml` and this links to all other files. We recommend using VS Code to open this folder and using the [OpenAPI Swagger Editor](https://github.com/42Crunch/vscode-openapi) extension to assist with navigation.

To build the complete specification in a readable form we recommend [redoc-cli](https://github.com/Redocly/redoc). Builds can be done by running: `redoc-cli bundle .\todo-api.v1.yaml` which will generate a redoc static html file. 