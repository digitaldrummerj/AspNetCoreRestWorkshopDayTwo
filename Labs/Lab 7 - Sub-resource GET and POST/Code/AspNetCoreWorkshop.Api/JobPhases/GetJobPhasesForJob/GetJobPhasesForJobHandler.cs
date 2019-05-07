using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWorkshop.Api.JobPhases.GetJobPhasesForJob
{
    public class GetJobPhasesForJobHandler : ValidatedRequestHandler<GetJobsPhasesForJobRequest, IActionResult>
    {
        public GetJobPhasesForJobHandler(
            IEnumerable<IValidator<GetJobsPhasesForJobRequest>> validators,
            WorkshopDbContext workshopDbContext,
            IMapper mapper) : base(validators)
        {
            WorkshopDbContext = workshopDbContext ?? throw new System.ArgumentNullException(nameof(workshopDbContext));
            Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public WorkshopDbContext WorkshopDbContext { get; }
        public IMapper Mapper { get; }

        protected override async Task<IActionResult> OnHandle(GetJobsPhasesForJobRequest message, CancellationToken cancellationToken)
        {
            //TODO: make sure Job exists in database - if not, return NotFoundResult

            //TODO: query WorkshopDbContext.JobPhases where JobId == message.JobId, then project to GetJobPhasesForJobResponse
            
            throw new NotImplementedException();
        }
    }
}