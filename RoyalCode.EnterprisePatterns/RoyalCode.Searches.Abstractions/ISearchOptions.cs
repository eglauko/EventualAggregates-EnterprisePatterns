﻿namespace RoyalCode.Searches.Abstractions;

/// <summary>
/// Options that can be applied into searches.
/// </summary>
/// <typeparam name="TSearch">The search component type.</typeparam>
public interface ISearchOptions<TSearch>
{
    /// <summary>
    /// <para>
    ///     Defines that the query will be paged and determines the number of items per page.
    /// </para>
    /// <para>
    ///     The default value is 10 items per page.
    /// </para>
    /// <para>
    ///     When zero (0) is entered, it will not be paged.
    /// </para>
    /// </summary>
    /// <param name="itemsPerPage">Items per page.</param>
    /// <returns>The same instance of the search for chaining calls.</returns>
    TSearch UsePages(int itemsPerPage = 10);

    /// <summary>
    /// Número da página a ser pesquisada.
    /// </summary>
    TSearch FetchPage(int pageNumber);

    /// <summary>
    /// Atualiza a última contagem de registros.
    /// Utilizado para não realizar novamente o count dos registros.
    /// </summary>
    TSearch UseLastCount(int lastCount);

    /// <summary>
    /// Se deve aplicar a contagem de registros.
    /// </summary>
    /// <param name="useCount"></param>
    /// <returns></returns>
    TSearch UseCount(bool useCount = true);
}
