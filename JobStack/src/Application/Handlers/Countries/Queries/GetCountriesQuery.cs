﻿using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JobStack.Application.Handlers.Countries.Queries;

public class GetCountriesQuery : IRequest<IDataResult<IEnumerable<CountryDto>>>
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IDataResult<IEnumerable<CountryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCountriesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CountryDto>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CountryDto>>(
                 _mapper.Map<IEnumerable<CountryDto>>(
                      await _context.Countries

                      .Include(c => c.Vacancies)
                      .AsNoTracking()

                      .Include(c => c.Companies)
                      .AsNoTracking()

                      .Include(c => c.Candidates)
                      .AsNoTracking()

                      .Where(c => c.IsDeleted == false)
                      .ToListAsync()));
        }
    }
}
