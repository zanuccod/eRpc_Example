# eRpc_Example
 Simple example of use of gRPC and .NET 5

# Usage
    dotnet build
    dotnet run -p Server/Calculator
    dotnet run -p Client/Client localhost 11854 25 + 5
Accepted operators are: "+", "-", "*", "/"    


# Expected result will be 
    The calculated result is: 30
