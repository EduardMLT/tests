Imports System.IO

Module Module1

    Sub Main()
        Dim filename As String = "C:\test_Portaone\10m.txt"

        ' Вимірювання часу виконання
        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        Dim data As List(Of Integer) = ReadFile(filename)
        Dim statistics = CalculateStatistics(data)
        Dim longestIncreasingSeq As List(Of Integer) = FindLongestIncreasingSequence(data)
        Dim longestDecreasingSeq As List(Of Integer) = FindLongestDecreasingSequence(data)

        ' Зупинка таймера
        stopwatch.Stop()
        Dim elapsedTime As TimeSpan = stopwatch.Elapsed

        Console.WriteLine($"Max Value: {statistics.Max}")
        Console.WriteLine($"Min Value: {statistics.Min}")
        Console.WriteLine($"Median Value: {statistics.Median}")
        Console.WriteLine($"Mean Value: {statistics.Mean}")
        Console.WriteLine($"Longest Increasing Sequence: [{String.Join(",", longestIncreasingSeq)}]")
        Console.WriteLine($"Longest Decreasing Sequence: [{String.Join(",", longestDecreasingSeq)}]")
        Console.WriteLine($"Number of values in file: {data.Count}")
        Console.WriteLine($"Elapsed Time: {elapsedTime.TotalMilliseconds} ms")

        Console.ReadLine() ' Зачекати натискання клавіші для завершення програми
    End Sub

    Function ReadFile(filename As String) As List(Of Integer)
        Dim data As New List(Of Integer)()
        Using reader As New StreamReader(filename)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                Dim value As Integer
                If Integer.TryParse(line, value) Then
                    data.Add(value)
                End If
            End While
        End Using
        Return data
    End Function

    Function CalculateStatistics(data As List(Of Integer)) As (Max As Integer, Min As Integer, Median As Double, Mean As Double)
        Dim max_value As Integer = data.Max()
        Dim min_value As Integer = data.Min()
        Dim median_value As Double = CalculateMedian(data)
        Dim mean_value As Double = data.Average()
        Return (max_value, min_value, median_value, mean_value)
    End Function

    Function CalculateMedian(data As List(Of Integer)) As Double
        Dim sortedData = data.OrderBy(Function(x) x).ToList()
        Dim count As Integer = sortedData.Count
        If count Mod 2 = 0 Then
            Return (sortedData(count \ 2 - 1) + sortedData(count \ 2)) / 2.0
        Else
            Return sortedData(count \ 2)
        End If
    End Function

    Function FindLongestIncreasingSequence(data As List(Of Integer)) As List(Of Integer)
        Dim max_len As Integer = 0
        Dim current_len As Integer = 1
        Dim max_seq As New List(Of Integer)
        Dim current_seq As New List(Of Integer)
        current_seq.Add(data(0))

        For i As Integer = 1 To data.Count - 1
            If data(i) > data(i - 1) Then
                current_len += 1
                current_seq.Add(data(i))
            Else
                If current_len > max_len Then
                    max_len = current_len
                    max_seq = New List(Of Integer)(current_seq)
                End If
                current_len = 1
                current_seq = New List(Of Integer)
                current_seq.Add(data(i))
            End If
        Next

        If current_len > max_len Then
            max_seq = New List(Of Integer)(current_seq)
        End If

        Return max_seq
    End Function

    Function FindLongestDecreasingSequence(data As List(Of Integer)) As List(Of Integer)
        Dim max_len As Integer = 0
        Dim current_len As Integer = 1
        Dim max_seq As New List(Of Integer)
        Dim current_seq As New List(Of Integer)
        current_seq.Add(data(0))

        For i As Integer = 1 To data.Count - 1
            If data(i) < data(i - 1) Then
                current_len += 1
                current_seq.Add(data(i))
            Else
                If current_len > max_len Then
                    max_len = current_len
                    max_seq = New List(Of Integer)(current_seq)
                End If
                current_len = 1
                current_seq = New List(Of Integer)
                current_seq.Add(data(i))
            End If
        Next

        If current_len > max_len Then
            max_seq = New List(Of Integer)(current_seq)
        End If

        Return max_seq
    End Function

End Module
