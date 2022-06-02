class M_Sort
{
    static int ArrDivide(int[] arr, int left, int right)
    {
        int PivotValue, temp;
        int index_L, index_R;

        index_L = left;
        index_R = right;

        // Pivot값은 0번 인덱스의 값으로 설정
        PivotValue = arr[left];

        while(index_L < index_R)
        {
            while((index_L <= right) && (arr[index_L] < PivotValue))
            {
                index_L++;
            }

            while((index_R >= left) && (arr[index_R] > PivotValue))
            {
                index_R--;
            }

            // Swap
            if(index_L < index_R)
            {
                temp = arr[index_L];
                arr[index_L] = arr[index_R];
                arr[index_R] = temp;

                if(arr[index_L] == arr[index_R])
                {
                    index_R--;
                }
            }
        }
        //index_L 과 index_R 이 교차된 경우 반복문을 나와 해당 인덱스값을 리턴
        return index_R;
    }

    static void InsertSort(int[] arr)
    {
        for(int i = 1; i < arr.Length; i++)
        {
            int temp = arr[i];
            int aux = i - 1;

            while((aux >= 0) && (arr[aux] > temp))
            {
                arr[aux + 1] = arr[aux];
                aux--;
            }

            arr[aux + 1] = temp;
        }
    }

    static void CountingSort(int[] arr)
    {
        // 카운팅 배열 생성 
        int[] counting = new int[arr.Max() + 1];
        int[] result = new int[arr.Length];

        // 입력 배열값 각각 갯수만큼 카운팅 배열값에 카운트
        for(int i = 0; i < arr.Length; i++)
        {
            counting[arr[i]]++;
        }

        // 누적합을 진행해줌
        for(int i = 1; i < counting.Length; i++)
        {
            counting[i] += counting[i - 1];
        }

        // 
        for(int i = arr.Length - 1; i >= 0; i--)
        {
            int value = arr[i];
            counting[value]--;
            result[counting[value]] = value;
        }

        Console.WriteLine(String.Join("\n", result));
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if(left < right)
        {
            int PivotIndex = ArrDivide(arr, left, right);
            QuickSort(arr, left, PivotIndex - 1);
            QuickSort(arr, PivotIndex + 1, right);
        }
    }
}