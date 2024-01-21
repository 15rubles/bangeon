namespace Entity.Room
{
    public interface IRoom
    {
        public void UpdateIsPassed();

        public RoomData RoomData { get; }
    }
}