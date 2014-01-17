using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class CodeLookupReader : ICodeLookupReader, IDisposable
    {
        private UserProfilesContext _db;

        public CodeLookupReader(UserProfilesContext db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetCodeLookupsForLookup(string codeDesc)
        {
            var codeLookups = from c1 in _db.CodeLookups.AsEnumerable()
                              where c1.CodeDesc.Equals(codeDesc, StringComparison.OrdinalIgnoreCase) && c1.ParentCodeLookupId == null
                              join c2 in _db.CodeLookups on c1.CodeLookupId equals c2.ParentCodeLookupId
                              orderby c2.ShortDesc
                              select new
                              {
                                  LookupID = c2.CodeLookupId,
                                  LookupValue = c2.ShortDesc
                              };

            return codeLookups;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}
