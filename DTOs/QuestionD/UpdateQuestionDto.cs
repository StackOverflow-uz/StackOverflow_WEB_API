﻿namespace DTOs.QuestionD;

public class UpdateQuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
