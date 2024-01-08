using MediatR;

namespace SampleProject.Contract.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}