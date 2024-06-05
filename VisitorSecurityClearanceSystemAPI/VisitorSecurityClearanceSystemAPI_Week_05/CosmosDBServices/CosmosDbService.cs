using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.ComponentModel;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI_Week_05.CosmosDBServices
{
    public class CosmosService : ICosmosService
    {
        public Container _container;
        public CosmosService()
        {
            _container = GetContainer();
        }

        //Manager 
        public async Task<Manager> AddManagerAsync(Manager manager)
        {
            var response = await _container.CreateItemAsync(manager, new PartitionKey(manager.UId));
            return response.Resource;
        }

        public async Task<Manager> GetManagerByIdAsync(string uId)
        {
            try
            {
                var response = await _container.ReadItemAsync<Manager>(uId, new PartitionKey(uId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            try
            {
                var response = await _container.UpsertItemAsync(manager, new PartitionKey(manager.UId));
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public async Task<bool> DeleteManagerAsync(string uId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<Manager>(uId, new PartitionKey(uId));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

        }


        // **********************************
        public async Task<OfficeUser> AddOfficeUserAsync(OfficeUser officeUser)
        {
            var response = await _container.CreateItemAsync(officeUser, new PartitionKey(officeUser.UId));
            return response.Resource;
        }

        public async Task<OfficeUser> GetOfficeUserByIdAsync(string uId)
        {
            try
            {
                var response = await _container.ReadItemAsync<OfficeUser>(uId, new PartitionKey(uId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<bool> UpdateOfficeUserAsync(OfficeUser officeUser)
        {
            try
            {
                var response = await _container.UpsertItemAsync(officeUser, new PartitionKey(officeUser.UId));
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOfficeUserAsync(string uId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<OfficeUser>(uId, new PartitionKey(uId));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }



        //******************************
        public async Task<SecurityUser> AddSecurityUserAsync(SecurityUser securityUser)
        {
            var response = await _container.CreateItemAsync(securityUser, new PartitionKey(securityUser.UId));
            return response.Resource;
        }

        public async Task<SecurityUser> GetSecurityUserByIdAsync(string uId)
        {
            try
            {
                var response = await _container.ReadItemAsync<SecurityUser>(uId, new PartitionKey(uId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<bool> UpdateSecurityUserAsync(SecurityUser securityUser)
        {
            try
            {
                var response = await _container.UpsertItemAsync(securityUser, new PartitionKey(securityUser.UId));
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSecurityUserAsync(string uId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<SecurityUser>(uId, new PartitionKey(uId));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }
        //
        public async Task<Visitor> AddVisitor(Visitor visitor)
        {
            return await _container.CreateItemAsync<Visitor>(visitor);
        }

        

       

        public async Task<List<Visitor>> GetAllApprovedVisitor()
        {
            var visitors = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.ApprovedStatus == "approved" && q.Archieved == false && q.Active == true).AsEnumerable().ToList();
            return visitors;
        }

        public async Task<List<Visitor>> GetAllPendingVisitor()
        {
            var visitors = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.ApprovedStatus == "pending" && q.Archieved == false && q.Active == true).AsEnumerable().ToList();
            return visitors;
        }

        public async Task<List<Visitor>> GetAllRejectedVisitor()
        {
            var visitors = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.ApprovedStatus == "rejected" && q.Archieved == false && q.Active == true).AsEnumerable().ToList();
            return visitors;
        }

        public async Task<List<Visitor>> GetAllVisitor()
        {
            var visitors = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.Archieved == false && q.Active == true).AsEnumerable().ToList();
            return visitors;
        }

        public async Task<OfficeUser> GetOfficeUserbyUId(string UId)
        {
            var user = _container.GetItemLinqQueryable<OfficeUser>(true).Where(q => q.DocumentType == "officeUser" && q.UId == UId && q.Archieved == false && q.Active == true).AsEnumerable().FirstOrDefault();
            return user;
        }

        public async Task<SecurityUser> GetSecurityUserbyUId(string UId)
        {
            var user = _container.GetItemLinqQueryable<SecurityUser>(true).Where(q => q.DocumentType == "securityUser" && q.UId == UId && q.Archieved == false && q.Active == true).AsEnumerable().FirstOrDefault();
            return user;
        }

        public async Task<Visitor> GetVisitorByMobileNo(string MobileNo)
        {
            var visitor = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.MobileNo == MobileNo && q.ApprovedStatus == "approved" && q.Archieved == false && q.Active == true).AsEnumerable().FirstOrDefault();
            return visitor;
        }

        public async Task<Visitor> GetVisitorByVisitorId(string visitorId)
        {
            var visitor = _container.GetItemLinqQueryable<Visitor>(true).Where(q => q.DocumentType == "visitor" && q.VisitorId == visitorId && q.Archieved == false && q.Active == true).AsEnumerable().FirstOrDefault();
            return visitor;
        }

        public async Task<Manager> LoginManager(string username, string password)
        {
            var manager = _container.GetItemLinqQueryable<Manager>(true).Where(q => q.DocumentType == "manager" && q.Active == true && q.Archieved == false && q.UserName == username && q.Password == password).AsEnumerable().FirstOrDefault();
            return manager;
        }

        public async Task<OfficeUser> LoginOfficeUser(string username, string password)
        {
            var user = _container.GetItemLinqQueryable<OfficeUser>(true).Where(q => q.DocumentType == "officeUser" && q.Active == true && q.Archieved == false && q.UserName == username && q.Password == password).AsEnumerable().FirstOrDefault();
            return user;
        }

        public async Task<SecurityUser> LoginSecurityUser(string username, string password)
        {
            var user = _container.GetItemLinqQueryable<SecurityUser>(true).Where(q => q.DocumentType == "securityUser" && q.Active == true && q.Archieved == false && q.UserName == username && q.Password == password).AsEnumerable().FirstOrDefault();
            return user;
        }

        

        public async Task<Visitor> UpdateVisitor(Visitor visitor)
        {
            return await _container.UpsertItemAsync<Visitor>(visitor);
        }
    }
}