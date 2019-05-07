using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreWorkshop.Api.Jobs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWorkshop.Api.JobPhases.CreateJobPhaseForJob
{
    public class CreateJobPhaseForJobHandler : ValidatedRequestHandler<CreateJobPhaseForJobRequest, IActionResult>
    {
        public CreateJobPhaseForJobHandler(
            IEnumerable<IValidator<CreateJobPhaseForJobRequest>> validators,
            WorkshopDbContext workshopDbContext,
            IMapper mapper) : base(validators)
        {
            WorkshopDbContext = workshopDbContext ?? throw new System.ArgumentNullException(nameof(workshopDbContext));
            Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public WorkshopDbContext WorkshopDbContext { get; }
        public IMapper Mapper { get; }

        protected override async Task<IActionResult> OnHandle(CreateJobPhaseForJobRequest message, CancellationToken cancellationToken)
        {
            //TODO: create new Job from message, above, and save new phase to database
            //TODO: make sure job exists - if it doesn't return Not Found
            //TODO: return JobId/Id using OkObjectResult
            throw new NotImplementedException();
        }
    }
}