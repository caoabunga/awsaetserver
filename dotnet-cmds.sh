#!/usr/bin/env bash

# command for packaging lambda function into deployment zip file
# dotnet lambda package -c Debug -o ../HelloWorldLambdaDotNet.zip -f netcoreapp3.1

# command for deploying into aws
# dotnet lambda deploy-function MySimpleFunction

# command for invoking lambda function
dotnet lambda invoke-function MySimpleFunction -–region us-east-1