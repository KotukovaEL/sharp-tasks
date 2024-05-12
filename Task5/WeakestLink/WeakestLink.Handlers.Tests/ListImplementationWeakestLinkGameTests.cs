using Moq;
using System.Text;
using WeakestLink.Handlers.ListImplementation;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class ListImplementationWeakestLinkGameTests
    {
        [Fact]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_odd_and_every_2_are_strikeout_correctly()
        {
            var sb = new StringBuilder();

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() => 
                {
                    return sb.ToString();
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

        [Fact]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_even_and_every_2_are_strikeout_correctly()
        {
            var sb = new StringBuilder();

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    return sb.ToString();
                });

            var weakestLinkGame = new WeakestLinkGame(userInteractor.Object);
            weakestLinkGame.Run(10, 2);
            string expectedOutput = string.Join(null,
                "������������ ���� �����. �������� ����������� ������� 2",
                "����� 1. ��������� 2 �������. ����� ��������: 9",
                "����� 2. ��������� 4 �������. ����� ��������: 8",
                "����� 3. ��������� 6 �������. ����� ��������: 7",
                "����� 4. ��������� 8 �������. ����� ��������: 6",
                "����� 5. ��������� 10 �������. ����� ��������: 5",
                "����� 6. ��������� 3 �������. ����� ��������: 4",
                "����� 7. ��������� 7 �������. ����� ��������: 3",
                "����� 8. ��������� 1 �������. ����� ��������: 2",
                "����� 9. ��������� 9 �������. ����� ��������: 1",
                "���� ��������. ���������� ���������� ������ �����. ���������� 5");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_even_and_every_3_are_strikeout_correctly()
        {
            var sb = new StringBuilder();

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    return sb.ToString();
                });

            var weakestLinkGame = new WeakestLinkGame(userInteractor.Object);
            weakestLinkGame.Run(10, 5);
            string expectedOutput = string.Join(null,
                "������������ ���� �����. �������� ����������� ������� 5",
                "����� 1. ��������� 5 �������. ����� ��������: 9",
                "����� 2. ��������� 10 �������. ����� ��������: 8",
                "����� 3. ��������� 6 �������. ����� ��������: 7",
                "����� 4. ��������� 2 �������. ����� ��������: 6",
                "����� 5. ��������� 9 �������. ����� ��������: 5",
                "����� 6. ��������� 8 �������. ����� ��������: 4",
                "����� 7. ��������� 1 �������. ����� ��������: 3",
                "����� 8. ��������� 4 �������. ����� ��������: 2",
                "����� 9. ��������� 7 �������. ����� ��������: 1",
                "���� ��������. ���������� ���������� ������ �����. ���������� 3");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_odd_and_every_5_are_strikeout_correctly()
        {
            var sb = new StringBuilder();

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    return sb.ToString();
                });

            var weakestLinkGame = new WeakestLinkGame(userInteractor.Object);
            weakestLinkGame.Run(5, 5);
            string expectedOutput = string.Join(null,
                "������������ ���� �����. �������� ����������� ������� 5",
                "����� 1. ��������� 5 �������. ����� ��������: 4",
                "����� 2. ��������� 1 �������. ����� ��������: 3",
                "����� 3. ��������� 3 �������. ����� ��������: 2",
                "����� 4. ��������� 4 �������. ����� ��������: 1",
                "���� ��������. ���������� ���������� ������ �����. ���������� 2");

            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}
