#!/bin/sh

dotnet new sln --name BAS24.Product
for file in $(ls *.csproj)
do 
   mkdir -p ${file%.*}/ && mv $file ${file%.*}/
done

for file in $(ls) 
do 
  if [ $file != "BAS24.Product.sln" ] 
  then
    if [ $file != "script.sh" ]
    then
      dotnet sln add "${file}/${file}.csproj"
    fi 
  fi
done