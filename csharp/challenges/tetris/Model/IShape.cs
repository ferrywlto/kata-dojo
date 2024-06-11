    interface IShape 
    {
        void GoDown();
        void GoLeft();
        void GoRight();
        void RotateLeft();
        void RotateRight();
        void SetInitialPosition();
        Condition GetCondition();
        int ShapeValue { get; }
    }