using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using SIM.Base;
using SIM.Instances;

namespace SIM.Tool.Plugins.LinqpadTools.Repairers
{
    public class RoleManagerRepairer : MakeNodeCommentRepairer
    {
        protected override IEnumerable<string> GetPaths(XmlDocument doc, Instance instance)
        {
            return new String[]
            {
                "/configuration/sitecore/pipelines/indexing.filterIndex.outbound/processor[@type='Sitecore.ContentSearch.Pipelines.IndexingFilters.ApplyOutboundSecurityFilter, Sitecore.ContentSearch']"
            };
        }
    }
}
