using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Data
{
    internal class TournmentConfiguration : IEntityTypeConfiguration<Tournament.Core.Tournament>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tournament.Core.Tournament> builder)
        {
            throw new NotImplementedException();
        }
    }
}
