﻿namespace Application.DTOs;

public class SubredditCreationDto
{
    public String Title { get; set; }

    public SubredditCreationDto(String title)
    {
        Title = title;
    }
}