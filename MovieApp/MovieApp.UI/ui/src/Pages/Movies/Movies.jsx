import React , {useState , useEffect} from 'react'
import axios from 'axios'
import Single from "../../Components/Single/Single"
import CustomPagination from "../../Components/Pagination/CustomPagination"
import Genres from '../../Components/Genres/Genres'
import useGenre from "../../hooks/useGenre"
import Constants from '../../Utilities/Constants'

const Movies = () => {

  const [page, setPage] = useState(1);
  const [movies, setMovies] = useState([]);
  const [numOfPages, setNumOfPages] = useState();
  const [genres, setGenres] = useState([]);
  const [selectedGenre, setSelectedGenre] = useState();

  const fetchMovies = async () => {
      
      const url = Constants.API_URL_GET_MOVIES + page
        await axios.get(url)
              .then((response) => {
                  if(response.data.error ===  null){
                    setMovies(response.data.data)
                    setNumOfPages(108)
                }
              })
  }
  
  useEffect(() => {
      window.scroll(0, 0);
      selectedGenre && console.log(selectedGenre.name)
      fetchMovies();
  }, [page, selectedGenre]);

  return (
    <div>
      <span className='pageTitle' >Movies </span>
      <Genres
        type="movie"
        selectedGenre={selectedGenre}
        setSelectedGenre={setSelectedGenre}
        genres={genres}
        setGenres={setGenres}
        setPage={setPage}
      />
      <div className='trending'>
        { movies &&
            movies.map((c) => (
              <Single
                key={c.movieID}
                id={c.movieID}
                poster={c.imageLgUrl}
                title={c.name}
                date={c.date}
                media_type="movie"
                vote_average={c.rating}
              />
        ))}
      </div>
      {numOfPages > 1 && (
          <CustomPagination setPage={setPage} numOfPages={numOfPages} />
      )}
    </div>
  )
}

export default Movies