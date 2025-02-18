using CampusSafe.Domain.Base.Exceptions;
using CampusSafe.Infrastructure.Model;
using CampusSafe.Domain.Entities;
using CampusSafe.Domain.Interfaces.Repository;
using CampusSafe.Infrastructure.Mapping;
using Dapper;

namespace CampusSafe.Infrastructure.Repository;

public class UsersSqlSqlRepository(BaseSqlRepository baseSqlRepository) : IUserRepository
{
    private readonly BaseSqlRepository _baseSqlRepository = baseSqlRepository;

    public async Task<User> GetUserById(Guid id)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var user = await _baseSqlRepository.QueryAsync<UserDto>(Constants.UsersSqlQueries.GET_USER_BY_ID, parameters);
        return UserMapper.MapToUser(user.FirstOrDefault()) ?? throw new NoResultsException("No user found with the given id.");;
    }
}