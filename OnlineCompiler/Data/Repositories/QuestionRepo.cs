using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCompiler.Data.DBModels;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly OnlineCompilerDbContext _context;
        private readonly IMapper _mapper;

        public QuestionRepo(IMapper mapper)
        { 
            _mapper = mapper;
            _context = new OnlineCompilerDbContext();
        }
        public bool AddQuestion(QuestionDTO question)
        {   question.ResourceId = Guid.NewGuid();
            var questionEntity = _mapper.Map<QuestionDTO, Question>(question);
            _context.Questions.Add(questionEntity);
            _context.SaveChanges();
            return true;
        }

        public List<QuestionDTO> GetAllQuestions()
        {
            var questions = _context.Questions.Include(question => question.Answers).ToList();
            var dtos = _mapper.Map<List<Question>, List<QuestionDTO>>(questions);
            return dtos;
        }

        public QuestionDTO? GetQuestion(Guid id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.ResourceId == id);
            if (question == null)
            {
                return null;
            }
            return _mapper.Map<Question, QuestionDTO>(question);
        }

        public bool RemoveQuestion(Guid id)
        { 
            var question = _context.Questions.FirstOrDefault(q => q.ResourceId == id);
            if (question != null)
            { 
                _context.Questions.Remove(question);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
