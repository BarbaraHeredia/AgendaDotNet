﻿namespace APIAgenda.Pagination;

public class PaginationParameters
{
    const int maxPagSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPagSize) ? maxPagSize : value;
    }
}
