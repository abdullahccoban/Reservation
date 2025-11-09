namespace Reservation.Domain.Entities;

public class QaDomain
{
    public int Id { get; private set; } 
    public int HotelId  { get; private set; }
    public string Question { get; private set; }
    public DateTime QuestionDate { get; private set; }
    public string? Answer { get; private set; }
    public DateTime? AnswerDate { get; private set; }

    public QaDomain(int hotelId, string question, DateTime questionDate, string? answer, DateTime? answerDate, int id = 0)
    {
        if (string.IsNullOrEmpty(question)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        Question = question;
        QuestionDate = questionDate;
        Answer = answer;
        if (answerDate.HasValue)
            AnswerDate = answerDate;
        if (id != 0) Id = id;
    }
    
    public void Update(string? question, DateTime? questionDate, string? answer, DateTime? answerDate)
    {
        if (question is not null)
        {
            if (string.IsNullOrWhiteSpace(question)) 
                throw new ArgumentException("Question cannot be empty when provided.");
            
            Question = question;
        }
        
        if (answer is not null)
        {
            if (string.IsNullOrWhiteSpace(answer)) 
                throw new ArgumentException("Answer cannot be empty when provided.");
            
            Answer = answer;
        }
        
        if (questionDate.HasValue)
            QuestionDate = questionDate.Value;
        
        if (answerDate.HasValue)
            AnswerDate = answerDate.Value;
    }
}