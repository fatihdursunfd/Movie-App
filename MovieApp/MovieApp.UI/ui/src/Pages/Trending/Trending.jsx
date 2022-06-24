import React , { useEffect, useState } from 'react'
import axios from "axios"
import Single from "../../Components/Single/Single"
import "./Trending.css"
import CustomPagination from "../../Components/Pagination/CustomPagination" 
import Constants from '../../Utilities/Constants'

const Trending = () => {

  const [page, setPage] = useState(1);
  const [movies , setMovies] = useState([])

  const fetchTrending = async () => {
      const url = Constants.API_URL_GET_TRENDING
      await axios.get(url)
                  .then((response) => {
                      if(response.data.error ===  null){
                          setMovies(response.data.data)
                    }
                  })
  }

  useEffect( () => {
    fetchTrending();  
  } , [page])

  return (
    <div>
        <span className='pageTitle' > Trending </span>
        <div className='trending'>
            {movies.map( (c) => 
                < Single 
                  key={c.id}
                  id={c.id}
                  poster={c.image_lg}
                  title={c.name}
                  date={c.date }
                  media_type={"tv"}
                  vote_average={c.rating}
                />
          )}
        </div>
        <CustomPagination setPage={setPage} />
    </div>
  )
}

export default Trending