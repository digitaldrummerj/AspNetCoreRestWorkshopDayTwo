# Create a POST endpoint

This lab is all about adding data into your database via POST requests.

## Concepts

- Implement a create record POST request using the CQRS pattern.

## Tasks

Implement a /jobs POST request for creating a Job record. Most of the details here are pretty straightforward - this is applying what we've already learned. The goal is to re-implement the provided CQRS pattern and use that knowlege to create jobs and write tests. around Make sure to implement:

- Request (use AutoMapper to map the properties from the request to the entity)
- Validator (ensure that certain properties are required)
- Handler
- Tests to ensure that valid requests succeed and invalid requests are rejected.

You will end up creating:

- A folder called CreateJob with four files:
  - CreateJobRequest (copy all properties except the Id property from the Job object to this object)
  - CreateJobRequestHandler (code provided for you):

```csharp
public class CreateJobRequestHandler : ValidatedRequestHandler<CreateJobRequest, CreateJobResponse>
{
    public WorkshopDbContext WorkshopDbContext { get; }
    public IMapper Mapper { get; }

    public CreateJobRequestHandler(
        IEnumerable<IValidator<CreateJobRequest>> validators,
        WorkshopDbContext workshopDbContext,
        IMapper mapper)
        : base(validators)
    {
        WorkshopDbContext = workshopDbContext ?? throw new ArgumentNullException(nameof(workshopDbContext));
        Mapper = mapper;
    }

    protected override async Task<CreateJobResponse> OnHandle(CreateJobRequest message, CancellationToken cancellationToken)
    {
        var newJob = Mapper.Map<Job>(message);
        WorkshopDbContext.Add(newJob);
        await WorkshopDbContext.SaveChangesAsync(cancellationToken);
        return new CreateJobResponse(newJob.Id);
    }
}
```

  - CreateJobRequestValidator (Name, Number, and StartDate are required fields)
  - CreateJobResponse (you will return the ID of the new object you create)
- An entry in WorkshopMapper to map your CreateJobRequest to the Job object (we'll talk more about why we use the call to `ForMember` shortly)

```csharp
config.CreateMap<CreateJobRequest, Job>()
    .ForMember(m => m.Id, options => options.Ignore());
```

- A new method inside of your JobsController:

```csharp
[HttpPost]
public Task<IActionResult> CreateJob(CreateJobRequest request)
{
    return HandleRequestAsync(request);
}
```

- Tests of course! Test to make sure that:
    a) your validation code works correctly, for each field being validated
    b) that the object is saved to the database (you can either do a GET request against your API with your new ID OR you can get a copy of the WorkshopDbContext service from the `server.Host.Services.GetService<WorkshopDbContext>()` method).

If you want more hints, peek ahead to the "Completed" folder which contains the entire complete solution.