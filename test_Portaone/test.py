import numpy as np

def read_file(filename):
    with open(filename, 'r') as file:
        data = list(map(int, file.readlines()))
    return data

def calculate_statistics(data):
    max_value = max(data)
    min_value = min(data)
    median_value = np.median(data)
    mean_value = np.mean(data)
    return max_value, min_value, median_value, mean_value

def find_longest_increasing_sequence(data):
    max_len = 0
    current_len = 1
    max_seq = []
    current_seq = [data[0]]
    
    for i in range(1, len(data)):
        if data[i] > data[i-1]:
            current_len += 1
            current_seq.append(data[i])
        else:
            if current_len > max_len:
                max_len = current_len
                max_seq = current_seq[:]
            current_len = 1
            current_seq = [data[i]]
    
    if current_len > max_len:
        max_seq = current_seq
        
    return max_seq

def find_longest_decreasing_sequence(data):
    max_len = 0
    current_len = 1
    max_seq = []
    current_seq = [data[0]]
    
    for i in range(1, len(data)):
        if data[i] < data[i-1]:
            current_len += 1
            current_seq.append(data[i])
        else:
            if current_len > max_len:
                max_len = current_len
                max_seq = current_seq[:]
            current_len = 1
            current_seq = [data[i]]
    
    if current_len > max_len:
        max_seq = current_seq
        
    return max_seq

# Main
filename = 'C:\\test_Portaone\\10m.txt'  
data = read_file(filename)
max_value, min_value, median_value, mean_value = calculate_statistics(data)
longest_increasing_seq = find_longest_increasing_sequence(data)
longest_decreasing_seq = find_longest_decreasing_sequence(data)

print(f'Max Value: {max_value}')
print(f'Min Value: {min_value}')
print(f'Median Value: {median_value}')
print(f'Mean Value: {mean_value}')
print(f'Longest Increasing Sequence: {longest_increasing_seq}')
print(f'Longest Decreasing Sequence: {longest_decreasing_seq}')
print(f'Number of values in file: {len(data)}')