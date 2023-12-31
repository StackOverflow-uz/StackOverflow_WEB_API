using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces;

public interface IQuestionTagInterface
{
    Task<IEnumerable<QuestionTag>> GetAllAsync();

    Task<QuestionTag?> GetByIdAsync(int id);

    Task AddAsync(QuestionTag questiontag);

    Task UpdateAsync(QuestionTag questiontag);

    Task DeleteAsync(QuestionTag questiontag);
}
