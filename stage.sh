#!/bin/bash   
set -v

rm -rf stage
mkdir stage
dotnet publish -c Release -r linux-arm -o ../../stage/red src/red
cp red.service stage/red.service