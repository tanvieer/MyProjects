using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMethod
{
    public class DbTags
    {
        //public bool AddTags(int webid , string name , string attribute, string value)
        //{
        //    if (insertValidation(webid, name, attribute, value))
        //    {
        //        using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
        //        {
        //            Tag tag = new Tag
        //            {
        //                WebsiteID = webid,
        //                TagName = name,
        //                AttributeName = attribute,
        //                AttributeValue = value
        //            };
        //            db.Tags.InsertOnSubmit(tag);
        //            db.SubmitChanges();
        //            return true;
        //        }
        //    }
        //    else return false;               
        //}

        public List<Tag> LoadTag()
        {
            using (var context = new DemoModelEntitiesDataContext())
            {
                return context.Tags.ToList();
            }
        }

        public bool AddTags(Tag t)
        {
            if (insertValidation(t.WebsiteID, t.TagName, t.AttributeName, t.AttributeValue))
            {
                using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
                {
                    db.Tags.InsertOnSubmit(t);
                    db.SubmitChanges();
                    return true;
                }
            }
            else return false;
        }


        public bool UpdateTags(Tag newTag , Tag oldTag )
        {
            bool status = AddTags(newTag);
            if(status)
            {
                RemoveTag(oldTag.WebsiteID, oldTag.TagName, oldTag.AttributeName, oldTag.AttributeValue);
            }
            return status;
        }


        private bool insertValidation(int webid, string name, string attribute, string value)
        {
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                Tag  tag = ( db.Tags.SingleOrDefault(x => x.WebsiteID == webid && x.TagName == name && x.AttributeName == attribute && x.AttributeValue == value)  );
                if (tag == null)
                    return true;
                else return false;
            }
        }


        public bool RemoveTag(int webid, string name, string attribute, string value)
        {
            try
            {
                using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
                {
                    Tag tag = (db.Tags.SingleOrDefault(x => x.WebsiteID == webid && x.TagName == name && x.AttributeName == attribute && x.AttributeValue == value));
                    db.Tags.DeleteOnSubmit(tag);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            


        }
        
    }
}
