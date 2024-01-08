using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class TagRepository : Repository<Tag> , ITagInterface
{
    public TagRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
