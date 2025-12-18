var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo").AddDatabase("db");

var apiHost = builder.AddProject<Projects.Airline_Api_Host>("airline-api-host")
    .WithReference(db, "airlineClient")
    .WaitFor(db);

var batchSize = builder.AddParameter("GeneratorBatchSize");
var waitTime = builder.AddParameter("GeneratorWaitTime");

var grpcServer = builder.AddProject<Projects.Airline_Generator_Grpc_Host>("airline-generator-grpc-host")
    .WithEnvironment("Generator:BatchSize", batchSize)
    .WithEnvironment("Generator:WaitTime", waitTime);

apiHost.WithReference(grpcServer)
    .WithEnvironment("TicketGenerator__GrpcAddress", grpcServer.GetEndpoint("https"))
    .WaitFor(grpcServer);

builder.Build().Run();