import React , {useEffect } from 'react'
import axios from 'axios';
import Chip from '@mui/material/Chip';
import Constants from '../../Utilities/Constants';

const Genres = ({
    selectedGenre,
    setSelectedGenre,
    genres,
    setGenres,
    type,
    setPage, }) => {

    const handleAdd = (genre) => {
        setSelectedGenre(genre);
        fetchGenres()
        setGenres(genres.filter((g) => g.categoryID !== genre.categoryID));
        setPage(1);
    };
    
    const handleRemove = (genre) => {
        setSelectedGenre();
        setPage(1);
    };

    const fetchGenres = async () => {
        const url = Constants.API_URL_GET_CATEGORİES
        await axios.get(url)
              .then((response) => {
                  if(response.data.error ===  null){
                        setGenres(response.data.data)
                }
              })
    };

    useEffect(() => {
        fetchGenres();
    }, [setGenres]);

    return (
        <div style={{ padding: "6px 0" }}>
            { selectedGenre && 
                <Chip
                    style={{margin: 4 , fontSize:15 , fontFamily:"Montserrat" , backgroundColor:"#839AA8"}}
                    label={selectedGenre.name}
                    key={selectedGenre.categoryID + 61}
                    color="primary" 
                    clickable
                    size="small"
                    onDelete={() => handleRemove(selectedGenre)}
                />
            }
            {genres && genres.length > 0 &&  genres.map((genre) => (
                <Chip
                    style={{ margin: 4 , color:"white" , fontSize:15 , fontFamily:"Montserrat" , backgroundColor:"#393E46"  }}
                    label={genre.name}
                    key={genre.categoryID}
                    clickable
                    size="small"
                    onClick={() => handleAdd(genre)}
                />
            ))}
        </div>
    )
}

export default Genres