import axios from "axios";
import { useEffect, useState } from "react";
import Genres from "../../Components/Genres/Genres";
import CustomPagination from "../../Components/Pagination/CustomPagination";
import Single from "../../Components/Single/Single";
import useGenre from "../../hooks/useGenre";
const Series = () => {

  const [genres, setGenres] = useState([]);
  const [selectedGenres, setSelectedGenres] = useState([]);
  const [page, setPage] = useState(1);
  const [content, setContent] = useState([]);
  const [numOfPages, setNumOfPages] = useState();
  const genreforURL = useGenre(selectedGenres);

  useEffect(() => {
    window.scroll(0, 0);
    const fetchSeries = async () => {
        const url = `https://api.themoviedb.org/3/discover/tv?api_key=44f4b50a7a7b8ece939348ff65ba06f3&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=${page}&with_genres=${genreforURL}`
        const { data } = await axios.get(url);
        setContent(data.results);
        setNumOfPages(data.total_pages);
    };
    fetchSeries();
  }, [genreforURL, page]);

  return (
    <div>
      <span className="pageTitle">Discover Series</span>
      <Genres
        type="tv"
        selectedGenres={selectedGenres}
        setSelectedGenres={setSelectedGenres}
        genres={genres}
        setGenres={setGenres}
        setPage={setPage}
      />
      <div className="trending">
        {content &&
          content.map((c) => (
            <Single
              key={c.id}
              id={c.id}
              poster={c.poster_path}
              title={c.title || c.name}
              date={c.first_air_date || c.release_date}
              media_type="tv"
              vote_average={c.vote_average}
            />
          ))}
      </div>
      {numOfPages > 1 && (
        <CustomPagination setPage={setPage} numOfPages={numOfPages} />
      )}
    </div>
  )
}

export default Series