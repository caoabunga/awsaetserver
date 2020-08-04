#!/usr/bin/env bash
#zip function.zip index.js

aws --endpoint-url=http://localhost:4574 lambda delete-function --function-name dotnetfunction5

aws --endpoint-url=http://localhost:4574 lambda create-function --function-name=dotnetfunction5 --runtime=dotnetcore3.1 --role=arn:aws:iam::123456789012:role/lambda-ex  --handler=AETServer --zip-file fileb://aetserver.zip

# aws --endpoint-url=http://localhost:4574 lambda create-function --function-name=dotnetfunction5 --runtime=dotnetcore3.1 --role=arn:aws:iam::123456789012:role/lambda-ex --handler=DotNetCore31::dotnetcore31.Function::FunctionHandler --zip-file fileb://dotnetcao.zip

# aws --endpoint-url=http://localhost:4574 lambda invoke --function-name my-function out.json --log-type Tail 

# aws --endpoint-url=http://localhost:4574 lambda invoke --function-name my-function out.jon --log-type Tail --query 'LogResult' --output text |  base64 -d

# aws --endpoint-url=http://localhost:4574 lambda list-functions --max-items 10

# #aws --endpoint-url=http://localhost:4574 lambda delete-function --function-name my-function



