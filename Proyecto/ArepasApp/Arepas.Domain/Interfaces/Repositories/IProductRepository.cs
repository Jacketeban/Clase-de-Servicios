﻿using Arepas.Domain.Common;
using Arepas.Domain.Models;

namespace Arepas.Domain.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{

    public Task<Product> RemoveAsync(int id);
   
}