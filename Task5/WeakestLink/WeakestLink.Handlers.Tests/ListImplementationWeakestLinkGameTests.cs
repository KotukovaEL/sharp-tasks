using Moq;
using System.Text;
using WeakestLink.Handlers.ListImplementation;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class ListImplementationWeakestLinkGameTests
    {
        [Fact]
        public void Should_run_WeakestLinkGame_ListImplementation_correctly()
        {
            var sb = new StringBuilder();
            var inputs = new string[] { };
            var inputIndex = 0;

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() => 
                {
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

            var weakestLinkGame = new WeakestLinkGame(userInteractor.Object);
            weakestLinkGame.Run(5, 2);
            string expectedOutput = string.Join(null,
                "������������ ���� �����. �������� ����������� ������� 2",
                "����� 1. ��������� 2 �������. ����� ��������: 4",
                "����� 2. ��������� 4 �������. ����� ��������: 3",
                "����� 3. ��������� 1 �������. ����� ��������: 2",
                "����� 4. ��������� 5 �������. ����� ��������: 1",
                "���� ��������. ���������� ���������� ������ �����. ���������� 3");

            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}
