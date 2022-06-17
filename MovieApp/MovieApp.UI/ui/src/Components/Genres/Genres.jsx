import React , {useEffect } from 'react'
import axios from 'axios';
import Chip from '@mui/material/Chip';

const Genres = ({
    selectedGenres,
    setSelectedGenres,
    genres,
    setGenres,
    type,
    setPage, }) => {

    const handleAdd = (genre) => {
        setSelectedGenres([...selectedGenres, genre]);
        setGenres(genres.filter((g) => g.id !== genre.id));
        setPage(1);
    };
    
    const handleRemove = (genre) => {
        setSelectedGenres(selectedGenres.filter((selected) => selected.id !== genre.id));
        setGenres([...genres, genre]);
        setPage(1);
    };

    useEffect(() => {
        const fetchGenres = async () => {
            const url = `https://api.themoviedb.org/3/genre/${type}/list?api_key=44f4b50a7a7b8ece939348ff65ba06f3&language=en-US`
            const { data } = await axios.get(url);
            setGenres(data.genres);
        };
        fetchGenres();
        return () => { setGenres({}); };
    }, [setGenres]);

    return (
        <div style={{ padding: "6px 0" }}>
            {selectedGenres.map((genre) => (
                <Chip
                    style={{ margin: 2 }}
                    label={genre.name}
                    key={genre.id}
                    color="primary"
                    clickable
                    size="small"
                    onDelete={() => handleRemove(genre)}
                />
            ))}
            {genres.map((genre) => (
                <Chip
                    style={{ margin: 2 , color:"white" }}
                    label={genre.name}
                    key={genre.id}
                    clickable
                    size="small"
                    onClick={() => handleAdd(genre)}
                />
            ))}
        </div>
    )
}

export default Genres