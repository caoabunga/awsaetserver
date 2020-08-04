#!/usr/bin/env bash

# command for packaging lambda function into deployment zip file
# dotnet lambda package -c Debug -o ../aetserver.zip -f netcoreapp3.1 --msbuild-parameters "AETGatewayLambda.csproj"

# command for deploying into aws
# dotnet lambda deploy-function AETGetMethod --msbuild-parameters "AETGatewayLambda.csproj"

# command for invoking lambda function
dotnet lambda invoke-function MySimpleFunction -–region us-east-1

## installing sam cli for local lambda/api gateway testing

# brew tap aws/tap
# brew install aws-sam-cli

## verify install
# sam --version