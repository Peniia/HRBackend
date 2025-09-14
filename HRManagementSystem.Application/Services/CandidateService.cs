using HRManagementSystem.Application.Candidate.DTOs;
using HRManagementSystem.Infrastructure.Persistence;
using HRManagementSystem.Infrastructure.Repositories;
using HRManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.Services
{
    public class CandidateService
    {
        private readonly IRepository<Domain.Entities.Candidate> _candidateRepository;
        private readonly HRDbContext _context;

        public CandidateService(IRepository<Domain.Entities.Candidate> candidateRepository, HRDbContext context)
        {
            _candidateRepository = candidateRepository;
            _context = context;
        }

        public async Task<List<CandidateDto>> GetAllAsync()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            return candidates.Select(c => new CandidateDto
            {
                Id = c.Id,
                Name = c.Name,
                Position = c.Position,
                CvUrl = c.CvUrl,
                CvName = c.CvName,
                Status = c.Status,
                Note = c.Note
            }).ToList();
        }

        public async Task<CandidateDto> GetByIdAsync(int id)
        {
            var c = await _candidateRepository.GetByIdAsync(id);
            if (c == null) return null!;
            return new CandidateDto
            {
                Id = c.Id,
                Name = c.Name,
                Position = c.Position,
                CvUrl = c.CvUrl,
                CvName = c.CvName,
                Status = c.Status,
                Note = c.Note
            };
        }

        public async Task<int> CreateAsync(CreateCandidateDto dto)
        {
            var candidate = new Domain.Entities.Candidate
            {
                Name = dto.Name,
                Position = dto.Position,
                CvUrl = dto.CvUrl,
                CvName = dto.CvName
            };
            await _candidateRepository.AddAsync(candidate);
            await _candidateRepository.SaveChangesAsync();
            return candidate.Id;
        }

        public async Task<bool> UpdateAsync(int id, UpdateCandidateDto dto)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null) return false;

            candidate.Name = dto.Name;
            candidate.Position = dto.Position;
            candidate.CvUrl = dto.CvUrl;
            candidate.CvName = dto.CvName;
            candidate.Status = dto.Status;
            candidate.Note = dto.Note;

            _candidateRepository.Update(candidate);
            await _candidateRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null) return false;

            _candidateRepository.Remove(candidate);
            await _candidateRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatusAsync(int id, string status)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null) return false;
            candidate.Status = status;
            _candidateRepository.Update(candidate);
            await _candidateRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddNoteAsync(int id, string note)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null) return false;
            candidate.Note = note;
            _candidateRepository.Update(candidate);
            await _candidateRepository.SaveChangesAsync();
            return true;
        }
    }
}