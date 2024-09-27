namespace PSMobile.core.Interfaces;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; } // Itens da página atual
    public int TotalItems { get; set; } // Número total de itens na consulta
    public int PageNumber { get; set; } // Número da página atual
    public int PageSize { get; set; } // Número de itens por página
    public int TotalPages { get; set; } // Número total de páginas

    public PaginatedResult(List<T> items, int totalItems, int pageNumber, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }

    // Indica se há uma página anterior
    public bool HasPreviousPage => PageNumber > 1;

    // Indica se há uma próxima página
    public bool HasNextPage => PageNumber < TotalPages;

    public static PaginatedResult<T> Empty(int pageNumber, int pageSize)
    {
        return new PaginatedResult<T>(new List<T>(), pageNumber, pageSize, 0);
    }
}
